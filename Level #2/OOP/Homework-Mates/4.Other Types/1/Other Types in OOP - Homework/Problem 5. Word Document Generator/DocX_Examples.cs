namespace Problem_5.Word_Document_Generator
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using Novacode;

    public class DocX_Examples
    {
        public void CreateSampleDocument()
        {
            // SOURCE:
            // Heading Paragraph
            string myH1 = "SoftUni OOP Game Contest";

            // Image path 
            string imagePath = @"../../Source/rpg-game.png";

            // Paragraph
            string text1a = "SoftUni is organizing a contest for the best ";
            string text1b = "role playing game";
            string text1c = " from the OOP teamwork projects. The winning teams will receive a ";
            string text1d = "grand prize";
            string text1e = "!";
            string text1f = "The game should be:";

            // BulletList
            string[] myBulletList = new string[] { "Properly structured and follow all good OOP practices", "Awesome", "..Very Awesome" };

            // Table content
            string[,] tableContent = new string[4, 3] { { "Team", "Game", "Points" }, { "-", "-", "-" }, { "-", "-", "-" }, { "-", "-", "-" } };

            // Paragraph 2
            string text2a = "The top 3 teams will receive a ";
            string text2b = "SPECTACULAR";
            string text2c = " prize:";

            // Paragraph 3
            string text3 = @"A HANDSHAKE FROM NAKOV";

            try
            {
                // Modify to suit your machine:
                string fileName = @"./DocXExample.docx";

                using (DocX document = DocX.Create(fileName))
                {
                    // A formatting object for our headline:
                    var headLineFormat = new Formatting();
                    headLineFormat.FontFamily = new System.Drawing.FontFamily("Arial");
                    headLineFormat.Size = 18D;
                    headLineFormat.Position = 20;
                    headLineFormat.Bold = true;

                    Paragraph p1 = document.InsertParagraph(myH1, false, headLineFormat);
                    p1.Alignment = Alignment.center;

                    // Add an Image to the docx file
                    Novacode.Image img = document.AddImage(imagePath);

                    Paragraph imgParagraph = document.InsertParagraph(string.Empty, false);
                    Picture pic1 = img.CreatePicture();

                    // Set Size
                    pic1.Height = 250;
                    pic1.Width = 630;
                    imgParagraph.InsertPicture(pic1, 0);

                    // Add new Paragraph(3)
                    Paragraph p3 = document.InsertParagraph();
                    p3.AppendLine().Append(text1a)
                        .Append(text1b)
                        .Bold()
                        .Append(text1c)
                        .Append(text1d)
                        .Bold()
                        .UnderlineStyle(UnderlineStyle.singleLine)
                        .Append(text1e)
                        .AppendLine()
                        .Append(text1f)
                        .AppendLine();

                    // Add Bullet list
                    var bulletedList = document.AddList(null, 0, ListItemType.Bulleted);
                    foreach (var item in myBulletList)
                    {
                        document.AddListItem(bulletedList, item);
                    }

                    List l = document.InsertList(bulletedList);
                    Paragraph emptyParagrph = document.InsertParagraph(string.Empty, false);

                    // Add table
                    Table table1 = document.InsertTable(tableContent.GetLength(0), tableContent.GetLength(1));
                    Border myTableBorder = new Border(BorderStyle.Tcbs_single, BorderSize.two, 0, Color.Black);
                    for (int i = 0; i < tableContent.GetLength(0); i++)
                    {
                        table1.Rows[i].Height = 25;
                        for (int j = 0; j < tableContent.GetLength(1); j++)
                        {
                            if (i == 0)
                            {
                                table1.Rows[i].Cells[j].FillColor = Color.SteelBlue;
                            }

                            table1.Rows[i].Cells[j].Paragraphs[0].Append(tableContent[i, j]);
                            table1.Rows[i].Cells[j].SetBorder(TableCellBorderType.Left, myTableBorder);
                            table1.Rows[i].Cells[j].SetBorder(TableCellBorderType.Top, myTableBorder);
                            table1.Rows[i].Cells[j].SetBorder(TableCellBorderType.Right, myTableBorder);
                            table1.Rows[i].Cells[j].SetBorder(TableCellBorderType.Bottom, myTableBorder);
                            table1.Rows[i].Cells[j].Width = 20;
                            table1.Rows[i].Cells[j].VerticalAlignment = VerticalAlignment.Center;
                            table1.Rows[i].Cells[j].Paragraphs[0].Alignment = Alignment.center;
                        }
                    }

                    table1.AutoFit = AutoFit.Window;
                    table1.Alignment = Alignment.center;
                    Paragraph emptyParagrph2 = document.InsertParagraph(string.Empty, false);

                    // Add new Paragraph(4)
                    Paragraph p4 = document.InsertParagraph();
                    p4.Append(text2a).Append(text2b).Bold().Append(text2c);
                    p4.Alignment = Alignment.center;

                    // Add new Paragraph(5)
                    var prizeFormat = new Formatting();
                    prizeFormat.FontFamily = new System.Drawing.FontFamily("Arial");
                    prizeFormat.Size = 36D;
                    prizeFormat.Position = 12;
                    prizeFormat.Bold = true;

                    Paragraph p5 = document.InsertParagraph(string.Empty, false, prizeFormat);
                    p5.Append(text3).Bold().UnderlineStyle(UnderlineStyle.singleLine).FontSize(26d).Color(Color.SteelBlue);
                    p5.Alignment = Alignment.center;

                    // Save to the output directory:
                    document.Save();

                    // Open in Word:
                    Process.Start("WINWORD.EXE", fileName);
                }
            }
            catch (Exception x)
            {
                // throw new Exception("Cannot create word document! Error: " + x.ToString());
                Console.WriteLine("Cannot create word document! Error: " + x.ToString());
            }
        }
    }
}
