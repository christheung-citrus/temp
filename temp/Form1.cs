using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace temp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //global varible declarations
        int userNum;
        int rowsToDraw, starsToDraw;
        int spacesToDraw, spacesBefore, spacesInside, spacesDrawn, starsDrawn;
        int row;

        //
        //BEGIN MAIN CODE
        //
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //get user input
            userNum = Convert.ToInt32(txtInput.Text);

            //width
            spacesDrawn = 0;
            starsDrawn = 0;
            spacesBefore = userNum - 1;
            spacesInside = userNum;

            //height
            rowsToDraw = (userNum * 3) - 2;

            //initalize output string as blank
            string output = "";

            //initalize row to 0
            row = 0;

            while (row < rowsToDraw)
            {
                //affects first row
                if (row == 0)
                {
                    DrawSpaces(ref output, spacesBefore);
                    DrawStars(ref output);

                    //modify values to get ready for drawing next rows
                    spacesBefore--;
                    spacesInside = userNum;
                    row++;
                }
                
                //affects rows immediately precedeing center of hexagon, but NOT the first row
                else if (row < userNum - 1)
                {
                    DrawNewLine(ref output);
                    DrawSpaces(ref output, spacesBefore);
                    DrawBorder(ref output);
                    DrawSpaces(ref output, spacesInside);
                    DrawBorder(ref output);

                    //modify values to get ready for drawing next rows
                    spacesBefore--;
                    spacesInside += 2;
                    row++;
                }

                //affects center of hexagon (rectangular portion)
                //wrriten as a mathematical expression, if n = userNum
                //rows userNum thru userNum + userNum
                else if (row < (2 * userNum) - 1)
                {
                    DrawNewLine(ref output);
                    DrawBorder(ref output);
                    DrawSpaces(ref output, (userNum * 3) - 4);
                    DrawBorder(ref output);

                    //modify values to get ready for drawing next rows
                    row++;
                    spacesBefore = 1;
                }

                //affects rows succeeding center of hexagon, but NOT the last row
                else if (row < (3 * userNum) - 3)
                {
                    if (row == (2 * userNum) - 1)
                    {
                        spacesInside = (userNum * 3) - 6;
                    }

                    DrawNewLine(ref output);
                    DrawSpaces(ref output, spacesBefore);
                    DrawBorder(ref output);
                    DrawSpaces(ref output, spacesInside);
                    DrawBorder(ref output);

                    //modify values to get ready for drawing next rows
                    spacesBefore++;
                    spacesInside -= 2;
                    row++;
                }

                //affects last row
                else
                {
                    DrawNewLine(ref output);
                    DrawSpaces(ref output, userNum - 1);
                    DrawStars(ref output);

                    row++;
                }
                lblResult.Text = output;
            }
        }

        //
        // BEGIN METHODS
        //
        //methods pass output string by reference because we are updating the original value
        private void DrawSpaces(ref string output, int outerOrInner)
        {
            spacesDrawn = 0;
            spacesToDraw = outerOrInner;
            while (spacesDrawn < spacesToDraw)
            {
                output = output + " ";
                spacesDrawn++;
            }
        }

        private void DrawStars(ref string output)
        {
            starsDrawn = 0;
            starsToDraw = userNum;
            while (starsDrawn < starsToDraw)
            {
                //calls the other method
                DrawBorder(ref output);
                starsDrawn++;
            }
        }

        private void DrawBorder(ref string output)
        {
            output = output + "*";
        }

        private void DrawNewLine(ref string output)
        {
            output = output + Environment.NewLine;
        }
    }
}
