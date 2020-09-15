using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenameGUI
{
    public partial class frmMain : Form
    {
        // Declare public vars
        public string breakline = "##################################################################################################################";

        public frmMain()
        {
            InitializeComponent();

            // Control Props
            cbNumFormat.Items.AddRange(new string[] { "2 Num - 01", "3 Num - 012", "4 Num - 0123", "5 Num - 01234" });
        }
        // ########################################################################### Functions
        // MessageBox
        void Msg(string msg)
        {
            MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Log to file
        void Log(string from, string log)
        {
            string logfile = Application.StartupPath + @"\AppLog.log";
            using (StreamWriter w = File.AppendText(logfile))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine($"{DateTime.Now.ToString("hh:mm:ss:fff tt")} ( {DateTime.Now.ToLongDateString()} )");
                w.WriteLine($"  Source : { from }");
                w.WriteLine($"  Error  : { log }");
                w.WriteLine("----------------------------------------------------------------------------");
            }
        }
        void LogFile(string log, string filename)
        {
            string logfile = Application.StartupPath + @"\" + filename;
            using (StreamWriter w = File.AppendText(logfile))
            {
                w.Write(log);
            }
        }
        // Return string from 0 (start) til it reached a string
        string GetUntilOrEmpty(string text, string stopAt)
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }
        // Return string from string start to string end
        string GetFromTil(string text, string start, string end)
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charStart = text.IndexOf(start, StringComparison.Ordinal);
                int charEnd = text.IndexOf(end, StringComparison.Ordinal);

                if (charStart > -1)
                {
                    if (charEnd > -1)
                    {
                        charEnd = charEnd - 1;
                        if (charEnd == 0)
                        {
                            try
                            {
                                return text.Substring(0, 1);
                            }
                            catch (Exception ex0)
                            {
                                // LogError
                                Log("GetFromTil", ex0.ToString());
                                return "";
                            }
                        }
                        else if (charEnd > 0)
                        {
                            if (charEnd > charStart)
                            {
                                try
                                {
                                    return text.Substring(charStart, charEnd);
                                }
                                catch (Exception ex0)
                                {
                                    // LogError
                                    Log("GetFromTil", ex0.ToString());
                                    return "";
                                }
                            }
                            else
                            {
                                return "";
                            }
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }

            return String.Empty;
        }
        // Return string with zeroes on the front
        string PaddedZero(string chapter_num, int pad)
        {
            try
            {
                int num = Convert.ToInt32(chapter_num);
                string ret = num.ToString("D"+pad.ToString());
                return ret;

            } catch (Exception ex)
            {
                // Error
                Log($"PaddedZero-{ ex.Source.ToString() }", ex.ToString());
                return "";
            }
        }
        // Get Directories from sDir
        List<String> GetDirectoryList(string sDir, string errFrom)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.Add(d);
                }
            }
            catch (Exception excpt)
            {
                Log(errFrom, excpt.ToString());
            }

            return files;
        }
        // Get Files from sDir
        List<String> GetFileList(string sDir, string errFrom)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
            }
            catch (Exception excpt)
            {
                Log(errFrom, excpt.ToString());
            }

            return files;
        }
        // List to Get, either "all files" or "all Folder Names"
        List<string> ListToGet(string folder, string calledFrom)
        {
            string errFrom = $"frmMain-ListToGet [calledFrom: {calledFrom}]";
            List<string> list = null;

            if (cbApplyDir.CheckState == CheckState.Checked)
            {
                list = GetDirectoryList(folder, errFrom);
            }
            else
            {
                list = GetFileList(folder, errFrom);
            }

            return list;
        }
        // ########################################################################### Events
        private void btnProcess_Click(object sender, EventArgs e)
        {
            // Exit if no source folder
            if (string.IsNullOrWhiteSpace(txtFolder.Text))
            {
                Msg("Folder source is empty!");
                txtFolder.Focus();
                return;
            }

            int count = 0;
            int countSkip = 0;
            string errFrom = "btnProcess_Click";
            string folder = txtFolder.Text;
            string cStart = txtStart.Text;
            string cEnd = txtEnd.Text;

            string writeLog = breakline;
            string writeRename = breakline;
            string writeSkipped = "";

            // Stripped string from folder names
            List<string> list = ListToGet(folder, errFrom);
            if (list.Count > 0)
            {
                foreach (string s in list)
                {
                    string name = "";
                    string nameNew = "";
                    try
                    {
                        name = Path.GetFileName(s);

                        writeLog += $"\nOld Name: { name }";

                        string stringtoReplace = GetFromTil(name, cStart, cEnd);

                        writeLog += $"\nString to Remove: { stringtoReplace }";

                        if (String.IsNullOrWhiteSpace(stringtoReplace))
                        {
                            writeLog += $"\nNew Name: Same. No Change";
                            // Add to skipped
                            writeSkipped += $"{ s }\nReason: Nothing to Replace\n\n";
                            countSkip += 1;
                        }
                        else
                        {
                            nameNew = name.Replace(stringtoReplace, "");
                            nameNew = nameNew.Trim();

                            writeLog += $"\nNew Name: { nameNew }";

                            // Rename folder
                            string pathOld, pathNew;
                            pathOld = s;
                            pathNew = Path.GetDirectoryName(s) + "\\" + nameNew;
                            writeRename += $"\nOld Path: { pathOld }";
                            writeRename += $"\nNew Path: { pathNew }";
                            writeRename += $"\n{ breakline }";

                            try
                            {
                                Directory.Move(pathOld, pathNew);
                                count += 1;

                            } catch (Exception ex1)
                            {
                                Log(errFrom, $"File: { s }\n  Error:\n{ ex1.ToString() }");
                                // Add to skipped
                                writeSkipped += $"{ s }\nReason: {ex1.ToString()}\n\n";
                                countSkip += 1;
                            }
                        }

                    } catch (Exception ex)
                    {
                        Log(errFrom, $"File: { s }\n  Error:\n{ ex.ToString() }");
                        // Add to skipped
                        writeSkipped += $"{ s }\nReason: {ex.ToString()}\n\n";
                        countSkip += 1;
                    }

                    writeLog += $"\n{ breakline }";
                }

                LogFile(writeLog, "LogNames.txt");
                LogFile(writeRename, "LogRenameFolders.txt");
                LogFile(writeSkipped, "LogSkipped.txt");
            }
            
            Msg($"Done!\n{count.ToString()} Folders are Changed!\nSkipped folders: {countSkip.ToString()}");
        }

        private void btnPadZero_Click(object sender, EventArgs e)
        {
            // Exit if no source folder
            if (string.IsNullOrWhiteSpace(txtFolder.Text))
            {
                Msg("Folder source is empty!");
                txtFolder.Focus();
                return;
            }

            // Exit if no selected Number format
            if (cbNumFormat.SelectedIndex < 0)
            {
                Msg("Select a Number Format!!");
                cbNumFormat.Focus();
                return;
            }

            // Continue, Declare vars
            string errFrom = "btnPadZero_Click";
            string folder = txtFolder.Text;
            int count = 0;
            int countSkip = 0;

            // Get pad number format
            int padFormat = 3;
            try
            {
                padFormat = Convert.ToInt32(cbNumFormat.Text.Substring(0, 1));

            } catch (Exception exx)
            {
                padFormat = 3;
                Log(errFrom, exx.ToString());
            }

            // Pad zeroes from folder name chapter numbers
            // Get all folder names from 'folder'
            List<string> list2 = ListToGet(folder, errFrom);
            if (list2.Count > 0)
            {
                string writePad = breakline;
                string writeSkipped = "Skipped:\n";
                string skipStart = txtStart.Text;
                string skipEnd = txtEnd.Text;

                foreach (string s2 in list2)
                {
                    // Vars
                    string name = "";

                    try
                    {
                        name = Path.GetFileName(s2);

                        string originChapterNum = "";
                        

                        // Skip certain strings?
                        if ((string.IsNullOrWhiteSpace(skipStart)==false) && (string.IsNullOrWhiteSpace(skipEnd) == false))
                        {
                            string strtoRep = GetFromTil(name, skipStart, skipEnd);
                            if (String.IsNullOrWhiteSpace(strtoRep) == false)
                            {
                                string stripped = name.Replace(strtoRep, "");
                                originChapterNum = Regex.Match(stripped, @"\d+").Value;
                            }
                            else
                            {
                                // Invalid
                                originChapterNum = "";
                            }
                        }
                        else
                        {
                            originChapterNum = Regex.Match(name, @"\d+").Value;
                        }

                        // Trim originChapterNum
                        originChapterNum = originChapterNum.Trim();
                        originChapterNum = originChapterNum.TrimStart('0');

                        // Check if 'originChapterNum' is valid
                        if (String.IsNullOrWhiteSpace(originChapterNum))
                        {
                            // No chapter number in folder name, leave it
                            // Add to skipped
                            writeSkipped += $"{ s2 }\nReason: String is empty\n\n";
                            countSkip += 1;
                        }
                        else
                        {
                            string newName = "";
                            string newPath = "";
                            string newChapterNum = PaddedZero(originChapterNum, padFormat);

                            try
                            {
                                // Replace chapter with padded zeroes
                                newName = name.Replace(originChapterNum, newChapterNum);
                                newPath = Path.GetDirectoryName(s2) + "\\" + newName;
                                Directory.Move(s2, newPath);
                                count += 1;

                            } catch (Exception exc)
                            {
                                // Log error
                                Log(errFrom, $"File: { s2 }\n  Error:\n{ exc.ToString() }");
                                // Add to skipped
                                writeSkipped += $"{ s2 }\nReason: {exc.ToString()}\n\n";
                                countSkip += 1;
                            }

                            writePad += $"\nOrigin: { s2 }";
                            writePad += $"\nStripped to Num: { originChapterNum }";
                            writePad += $"\nNew Name: { newName }";
                            writePad += $"\nNew Path: { newPath }";
                            writePad += "\n" + breakline;
                        }

                    }
                    catch (Exception ex)
                    {
                        Log(errFrom, $"File: { s2 }\n  Error:\n{ ex.ToString() }");
                        // Add to skipped
                        writeSkipped += $"{ s2 }\nReason: {ex.ToString()}\n\n";
                        countSkip += 1;
                    }
                }

                LogFile(writePad, "LogPaddedWZeroes.txt");
                LogFile(writeSkipped, "LogSkipped.txt");
            }

            Msg($"Done padding zeroes!\n{count.ToString()} Folders are affected!\nSkipped folders: {countSkip.ToString()}");
        }

        private void btnStringReplace_Click(object sender, EventArgs e)
        {
            // Exit if no source folder
            if (string.IsNullOrWhiteSpace(txtFolder.Text))
            {
                Msg("Folder source is empty!");
                txtFolder.Focus();
                return;
            }

            int count = 0;
            int countSkip = 0;
            string errFrom = "btnProcess_Click";
            string folder = txtFolder.Text;

            string cOld = txtStringOld.Text;
            string cNew = txtStringNew.Text;

            string writeLog = breakline;
            string writeRename = breakline;
            string writeSkipped = "";

            // Stripped string from folder names
            List<string> list = ListToGet(folder, errFrom);
            if (list.Count > 0)
            {
                foreach (string s in list)
                {
                    string name = "";
                    string nameNew = "";
                    try
                    {
                        name = Path.GetFileName(s);

                        writeLog += $"\nOld Name: { name }";

                        if (String.IsNullOrWhiteSpace(name))
                        {
                            writeLog += $"\nString name is empty!";
                            // Add to skipped
                            writeSkipped += $"{ s }\nReason: Empty folder name\n\n";
                            countSkip += 1;
                        }
                        else
                        {
                            nameNew = name.Replace(cOld, cNew);
                            nameNew = nameNew.Trim();

                            writeLog += $"\nNew Name: { nameNew }";

                            // Rename folder
                            string pathOld, pathNew;
                            pathOld = s;
                            pathNew = Path.GetDirectoryName(s) + "\\" + nameNew;
                            writeRename += $"\nOld Path: { pathOld }";
                            writeRename += $"\nNew Path: { pathNew }";
                            writeRename += $"\n{ breakline }";

                            try
                            {
                                Directory.Move(pathOld, pathNew);
                                count += 1;

                            }
                            catch (Exception ex1)
                            {
                                Log(errFrom, $"File: { s }\n  Error:\n{ ex1.ToString() }");
                                // Add to skipped
                                writeSkipped += $"{ s }\nReason: {ex1.ToString()}\n\n";
                                countSkip += 1;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Log(errFrom, $"File: { s }\n  Error:\n{ ex.ToString() }");
                        // Add to skipped
                        writeSkipped += $"{ s }\nReason: {ex.ToString()}\n\n";
                        countSkip += 1;
                    }

                    writeLog += $"\n{ breakline }";
                }

                LogFile(writeLog, "LogNames.txt");
                LogFile(writeRename, "LogRenameFolders.txt");
                LogFile(writeSkipped, "LogSkipped.txt");
            }

            string filetype = "files";
            if (cbApplyDir.CheckState == CheckState.Checked)
            {
                filetype = "Folders";
            }
            Msg($"Done replacing strings!\n{count.ToString()} {filetype} are affected!\nSkipped {filetype}: {countSkip.ToString()}");
        }
        // App load event
        private void frmMain_Load(object sender, EventArgs e)
        {
            Text = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;

            ToolTip tool = new ToolTip();
            tool.SetToolTip(btnPadZero, "Use the above parameters to ignore part of string from index of 'Delete string from'");
            tool.SetToolTip(btnProcess, "Remove string from index of 'Delete string from'");
            tool.SetToolTip(btnStringReplace, "Replace all occurence of string with another string");
            tool.SetToolTip(cbApplyDir, "Checked: Apply to folders inside the source folder\nUnchecked: Apply to Files inside the source folder");
        }

        private void btnListJson_Click(object sender, EventArgs e)
        {
            // List to JSON file
            string errFrom = "btnListJson_Click";
            string folder = txtFolder.Text;
            string format = "";
            string chapter = "", chapterName = "";
            string logJson = "JSONLog.log";

            List<string> list = ListToGet(folder, errFrom);
            
            if (list.Count > 0)
            {
                list.Sort((a, b) => b.CompareTo(a)); // descending sort

                foreach (string folderName in list)
                {
                    try
                    {
                        chapterName = Path.GetFileName(folderName);
                        chapter = GetFromTil(chapterName, ".", "_").TrimStart('.');
                        chapter = chapter.TrimStart('0').TrimEnd('_');

                        if (String.IsNullOrWhiteSpace(chapter) == false)
                        {
                            format = "{\n\t\"chap\": \"" + chapter + "\",\n\t";
                            format += "\"page\":\n\t[\n\t\t";
                            format += "{\"id\":\"0\", \"str\":\"";

                            // add formatted chapter name
                            int start = chapterName.IndexOf("_");
                            int len = chapterName.Length - start;
                            string chapterNameFormatted = chapterName.Substring(start, len).ToLower();
                            chapterNameFormatted = chapterNameFormatted.Replace("(", String.Empty).Replace(")", String.Empty);
                            chapterNameFormatted = chapterNameFormatted.TrimStart('_').Trim();

                            format += chapterNameFormatted;
                            format += "\"}\n\t]\n},\n";
                            LogFile(format, "JSON.txt");
                            LogFile(chapterNameFormatted + "\n", logJson);
                        }

                    } catch (Exception ex)
                    {
                        // Error
                        string log = "\nDirectory: " + folderName + "\nError: " + ex.ToString() + "\n";
                        LogFile(log, "JSONError.txt");
                    }
                }

                Msg("Done!");
            }
        }
    }
}
