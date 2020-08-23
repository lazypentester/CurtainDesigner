using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace CurtainDesigner.Classes
{
    public class Print
    {
        private static string SavePath = Classes.PathCombiner.join_combine("\\");
        private string Order_num = "0";

        public void print(List<KeyValuePair<string, object>> keyValuePairs, string TemplatePath)
        {
            Word.Document wordDocument = null;
            var wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                wordDocument = wordApp.Documents.Open(TemplatePath);
                wordDocument.Activate();

                foreach (var pair in keyValuePairs)
                {
                    switch (pair.Key)
                    {
                        case "{picture}":
                            ReplaceWord(pair.Key, "", wordDocument);
                            InsertImg(pair.Value.ToString(), 285, 570, 200, 200, wordDocument);
                            break;

                        case "{fabric_category_price}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "$"), wordDocument);
                            break;

                        case "{count}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "шт."), wordDocument);
                            break;

                        case "{width}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "м."), wordDocument);
                            break;

                        case "{height}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "м."), wordDocument);
                            break;

                        case "{yardage}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "м2"), wordDocument);
                            break;

                        case "{equipment_price}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "$"), wordDocument);
                            break;

                        case "{installation_price}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "$"), wordDocument);
                            break;

                        case "{price}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "$"), wordDocument);
                            break;

                        default:
                            ReplaceWord(pair.Key, pair.Value, wordDocument);
                            break;
                    }
                }

                wordApp.Visible = true;

                wordApp.Dialogs[Word.WdWordDialog.wdDialogFilePrint].Show();
                
                while(wordApp.BackgroundPrintingStatus > 0)
                {
                    Thread.Sleep(1000);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Помилка при роздрукуванні документа.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(wordDocument != null)
                    wordDocument.Close(SaveChanges: false);
                wordApp.Quit(SaveChanges: false);
            }
        }

        public void saveAsWord(List<KeyValuePair<string, object>> keyValuePairs, string TemplatePath)
        {
            Word.Document wordDocument = null;
            var wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                wordDocument = wordApp.Documents.Open(TemplatePath);
                wordDocument.Activate();

                foreach (var pair in keyValuePairs)
                {
                    switch (pair.Key)
                    {
                        case "{picture}":
                            ReplaceWord(pair.Key, "", wordDocument);
                            InsertImg(pair.Value.ToString(), 285, 570, 200, 200, wordDocument);
                            break;

                        case "{fabric_category_price}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "$"), wordDocument);
                            break;

                        case "{count}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "шт."), wordDocument);
                            break;

                        case "{width}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "м."), wordDocument);
                            break;

                        case "{height}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "м."), wordDocument);
                            break;

                        case "{yardage}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "м2"), wordDocument);
                            break;

                        case "{equipment_price}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "$"), wordDocument);
                            break;

                        case "{installation_price}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "$"), wordDocument);
                            break;

                        case "{price}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "$"), wordDocument);
                            break;

                        default:
                            ReplaceWord(pair.Key, pair.Value, wordDocument);
                            break;
                    }
                }

                Order_num = keyValuePairs.Where(x => x.Key == "{fb_id}").Select(x => x.Value).SingleOrDefault().ToString();

                wordDocument.SaveAs2($@"{SavePath}\Замовлення №{Order_num}");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при роздрукуванні документа.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (wordDocument != null)
                    wordDocument.Close(SaveChanges: false);
                wordApp.Quit(SaveChanges: false);
            }
        }

        public void saveAsPdf(List<KeyValuePair<string, object>> keyValuePairs, string TemplatePath)
        {
            Word.Document wordDocument = null;
            var wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                wordDocument = wordApp.Documents.Open(TemplatePath);
                wordDocument.Activate();

                foreach (var pair in keyValuePairs)
                {
                    switch (pair.Key)
                    {
                        case "{picture}":
                            ReplaceWord(pair.Key, "", wordDocument);
                            InsertImg(pair.Value.ToString(), 285, 570, 200, 200, wordDocument);
                            break;

                        case "{fabric_category_price}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "$"), wordDocument);
                            break;

                        case "{count}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "шт."), wordDocument);
                            break;

                        case "{width}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "м."), wordDocument);
                            break;

                        case "{height}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "м."), wordDocument);
                            break;

                        case "{yardage}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "м2"), wordDocument);
                            break;

                        case "{equipment_price}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "$"), wordDocument);
                            break;

                        case "{installation_price}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "$"), wordDocument);
                            break;

                        case "{price}":
                            ReplaceWord(pair.Key, string.Join(" ", pair.Value, "$"), wordDocument);
                            break;

                        default:
                            ReplaceWord(pair.Key, pair.Value, wordDocument);
                            break;
                    }
                }

                Order_num = keyValuePairs.Where(x => x.Key == "{fb_id}").Select(x => x.Value).SingleOrDefault().ToString();

                wordDocument.ExportAsFixedFormat($@"{SavePath}\Замовлення №{Order_num}", Word.WdExportFormat.wdExportFormatPDF, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при роздрукуванні документа.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (wordDocument != null)
                    wordDocument.Close(SaveChanges: false);
                wordApp.Quit(SaveChanges: false);
            }
        }

        private void ReplaceWord(string stubToReplace, object obj, Word.Document document)
        {
            try
            {
                var range = document.Content;
                range.Find.ClearFormatting();
                range.Find.Execute(FindText: stubToReplace, ReplaceWith: obj);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Помилка при роздрукуванні документа.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertImg(string path, int x, int y, int width, int height, Word.Document document)
        {
            try
            {
                document.Shapes.AddPicture(FileName: path, Left: x, Top: y, Width: width, Height: height);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при роздрукуванні документа.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool GetSavePath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Будь ласка, виберіть ПОРОЖНЮ папку для збереження файлу. Або створіть нову папку у будь-якому зручному для Вас місці.";
            fbd.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                SavePath = fbd.SelectedPath;
            }
            else
                return false;
            return true;
        }
    }
}
