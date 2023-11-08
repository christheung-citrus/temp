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

        //varible declarations
        int userNum;
        int rowsToDraw, starsToDraw;
        int spacesToDraw, spacesBefore, spacesInside, spacesDrawn, starsDrawn;
        int row;

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

            //extra variables we somehow need
            string output = "";
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
                
                //affects rows immediately precedeing center of hexagon, but not the first row
                else if (row < userNum - 1)
                {
                    output = output + Environment.NewLine;

                    DrawSpaces(ref output, spacesBefore);

                    output = output + "*";

                    DrawSpaces(ref output, spacesInside);

                    //modify values to get ready for drawing next rows
                    output = output + "*";
                    spacesBefore--;
                    spacesInside += 2;
                    row++;
                }

                //affects center of hexagon (rectangular portion)
                else if (row < (2 * userNum) - 1)
                {
                    output = output + Environment.NewLine;
                    output = output + "*";

                    DrawSpaces(ref output, (userNum * 3) - 4);

                    //modify values to get ready for drawing next rows
                    output = output + "*";
                    row++;
                    spacesBefore = 1;
                }

                //affects rows succeeding center of hexagon, but not the last row
                else if (row < (3 * userNum) - 3)
                {
                    if (row == (2 * userNum) - 1)
                    {
                        spacesInside = (userNum * 3) - 6;
                    }

                    output = output + Environment.NewLine;
                    
                    DrawSpaces(ref output, spacesBefore);

                    output = output + "*";

                    DrawSpaces(ref output, spacesInside);

                    output = output + "*";

                    //modify values to get ready for drawing next rows
                    spacesBefore++;
                    spacesInside -= 2;
                    row++;
                }

                //affects last row
                else
                {
                    output = output + Environment.NewLine;
                    
                    DrawSpaces(ref output, userNum - 1);
                    DrawStars(ref output);

                    row++;
                }
                lblResult.Text = output;
            }
        }

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
                output = output + "*";
                starsDrawn++;
            }
        }
    }
}
