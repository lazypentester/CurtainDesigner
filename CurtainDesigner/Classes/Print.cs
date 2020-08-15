using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace CurtainDesigner.Classes
{
    public class Print
    {
        private string SavePath = Classes.PathCombiner.join_combine("\\");
        public bool savePathRes = false;
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

                keyValuePairs.ForEach(x => ReplaceWord(x.Key, x.Value, wordDocument));

                wordApp.Visible = true;

                var dialogResult = wordApp.Dialogs[Word.WdWordDialog.wdDialogFilePrint].Show();
                
                

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

                keyValuePairs.ForEach(x => ReplaceWord(x.Key, x.Value, wordDocument));
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

                foreach(var pair in keyValuePairs)
                {
                    if (pair.Key != "{picture}")
                        ReplaceWord(pair.Key, pair.Value, wordDocument);
                    else
                    {
                        ReplaceWord(pair.Key, "", wordDocument);
                        InsertImg(pair.Value.ToString(), 285, 570, 200, 200, wordDocument);
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
            var range = document.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: obj);
        }

        private void InsertImg(string path, int x, int y, int width, int height, Word.Document document)
        {
            document.Shapes.AddPicture(FileName:path, Left:x, Top:y, Width: width, Height: height);
        }

        public void GetSavePath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Будь ласка, виберіть ПОРОЖНЮ папку для збереження файлу. Або створіть нову папку у будь-якому зручному для Вас місці.";
            fbd.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                savePathRes = true;
                SavePath = fbd.SelectedPath;
            }
        }
    }
}
