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

        //a hexagon is a reduced square, and as such will be the same dimensions vertically and horizontally
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
                if (row == 0)
                {
                    spacesDrawn = 0;
                    spacesToDraw = spacesBefore;
                    while (spacesDrawn < spacesToDraw)
                    {
                        output = output + " ";
                        spacesDrawn++;
                    }

                    starsDrawn = 0;
                    starsToDraw = userNum;
                    while (starsDrawn < starsToDraw)
                    {
                        output = output + "*";
                        starsDrawn++;
                    }

                    spacesBefore--;
                    spacesInside = userNum;
                    row++;
                }
                else if (row < userNum - 1)
                {
                    output = output + Environment.NewLine;

                    spacesDrawn = 0;
                    spacesToDraw = spacesBefore;
                    while (spacesDrawn < spacesToDraw)
                    {
                        output = output + " ";
                        spacesDrawn++;
                    }

                    output = output + "*";
                    spacesDrawn = 0;
                    spacesToDraw = spacesInside;
                    while (spacesDrawn < spacesToDraw)
                    {
                        output = output + " ";
                        spacesDrawn++;
                    }

                    output = output + "*";
                    spacesBefore--;
                    spacesInside += 2;
                    row++;
                }
                else if (row < (2 * userNum) - 1)
                {
                    output = output + Environment.NewLine;

                    output = output + "*";
                    spacesDrawn = 0;
                    spacesInside = (userNum * 3) - 4;
                    spacesToDraw = spacesInside;

                    while (spacesDrawn < spacesToDraw)
                    {
                        output = output + " ";
                        spacesDrawn++;
                    }

                    output = output + "*";
                    row++;
                    spacesBefore = 1;
                }
                else if (row < (3 * userNum) - 3)
                {
                    if (row == (2 * userNum) - 1)
                    {
                        spacesInside = (userNum * 3) - 6;
                    }

                    output = output + Environment.NewLine;
                    spacesDrawn = 0;
                    spacesToDraw = spacesBefore;

                    while (spacesDrawn < spacesToDraw)
                    {
                        output = output + " ";
                        spacesDrawn++;
                    }

                    output = output + "*";
                    spacesDrawn = 0;
                    spacesToDraw = spacesInside;

                    while (spacesDrawn < spacesToDraw)
                    {
                        output = output + " ";
                        spacesDrawn++;
                    }

                    output = output + "*";
                    spacesBefore++;
                    spacesInside -= 2;
                    row++;
                }
                else
                {
                    output = output + Environment.NewLine;
                    spacesBefore = userNum - 1;
                    spacesDrawn = 0;
                    spacesToDraw = spacesBefore;

                    while (spacesDrawn < spacesToDraw)
                    {
                        output = output + " ";
                        spacesDrawn++;
                    }

                    starsDrawn = 0;
                    starsToDraw = userNum;

                    while (starsDrawn < starsToDraw)
                    {
                        output = output + "*";
                        starsDrawn++;
                    }

                    row++;
                }
                lblResult.Text = output;
            }


        }
    }
}
