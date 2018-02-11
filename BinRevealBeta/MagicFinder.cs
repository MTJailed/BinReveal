using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinRevealBeta
{



    public class Magic
    {
        private static Dictionary<string, byte[]> _signatures = new Dictionary<string, byte[]>();
        public Dictionary<string, byte[]> Signatures
        {
            get { return _signatures; }
        }

        public Magic()
        {
            _signatures.Add("ELF Executable", new byte[] { 0x7F, 0x45, 0x4C, 0x46 });
            _signatures.Add("Binary propertylist", new byte[] { 0x62, 0x70, 0x6C, 0x69, 0x73, 0x74 });
            _signatures.Add("CPIO Archive", new byte[] { 0x30, 0x37, 0x30, 0x37, 0x30 });
            _signatures.Add("3GP5 MP4 Video", new byte[] { 0x00, 0x00, 0x00, 0x18, 0x66, 0x74, 0x79, 0x70 });
            _signatures.Add("7-Zip compressed archive", new byte[] { 0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C });
            _signatures.Add("MS-Access database 2007", new byte[] { 0x00, 0x01, 0x00, 0x00, 0x53, 0x74, 0x61, 0x6E, 0x64, 0x61, 0x72, 0x64, 0x20, 0x41, 0x43, 0x45, 0x20, 0x44, 0x42 });
            _signatures.Add("Access project", new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 });
            _signatures.Add("ASF Windows Media Video", new byte[] { 0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11 });
            _signatures.Add("Speedtouch router firmware", new byte[] { 0x42, 0x4C, 0x49, 0x32, 0x32, 0x33, 0x51 });
            _signatures.Add("Bzip2 compressed archive", new byte[] { 0x42, 0x5A, 0x68 });
            _signatures.Add("Bitmap Image", new byte[] { 0x42, 0x4D });
            _signatures.Add("Package sniffer data", new byte[] { 0x58, 0x43, 0x50, 0x00 });
            _signatures.Add("Windows calendar info", new byte[] { 0xB5, 0xA2, 0xB0, 0xB3, 0xB3, 0xB0, 0xA5, 0xB5 });
            _signatures.Add("Microsoft help file", new byte[] { 0x49, 0x54, 0x53, 0x46 });
            _signatures.Add("WhereIsIt catalog", new byte[] { 0x43, 0x61, 0x74, 0x61, 0x6C, 0x6F, 0x67, 0x20 });
            _signatures.Add("Microsoft .NET code", new byte[] { 0x75, 0x73, 0x69, 0x6e, 0x67, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6d, 0x3b });
            _signatures.Add("Skype userdata file", new byte[] { 0xB1, 0x68, 0xDE, 0x3A });
            _signatures.Add("Outlook email folder", new byte[] { 0xCF, 0xAD, 0x12, 0xFE });
            _signatures.Add("MS Word document (2007)", new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 });
            _signatures.Add("MS Word document", new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 });
            _signatures.Add("Visual Studio Workspace", new byte[] { 0x64, 0x73, 0x77, 0x66, 0x69, 0x6C, 0x65 });
            _signatures.Add("Mach-O file 32-bit Big Endian", new byte[] { 0xFE, 0xED, 0XFA, 0xCE });
            _signatures.Add("Mach-O file 64-bit Big Endian", new byte[] { 0xFE, 0xED, 0xFA, 0xCF });
            _signatures.Add("Mach-O file 32-bit Little Endian", new byte[] { 0xCE, 0xFA, 0xED, 0xFE });
            _signatures.Add("Mach-O file 64-bit Little Endian", new byte[] { 0xCF, 0xFA, 0xED, 0xFE });
            _signatures.Add("Email v1", new byte[] { 0x52, 0x65, 0x74, 0x75, 0x72, 0x6E, 0x2D, 0x50 });
            _signatures.Add("Email v2", new byte[] { 0x46, 0x72, 0x6F, 0x6D });
            _signatures.Add("GIF Image", new byte[] { 0x47, 0x49, 0x46, 0x38 });
            _signatures.Add("GZIP compressed archive", new byte[] { 0x1F, 0x8B, 0x08 });
            _signatures.Add("Java Archive v1", new byte[] { 0x50, 0x4B, 0x03, 0x04 });
            _signatures.Add("Java Archive v2", new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x08, 0x00 });
            _signatures.Add("JAR Archive", new byte[] { 0x5F, 0x27, 0xA8, 0x89 });
            _signatures.Add("JFIF JPEG Image", new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 });
            _signatures.Add("JPEG Image with metadata", new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 });
            _signatures.Add("Apple Audio Video File", new byte[] { 0x00, 0x00, 0x00, 0x20, 0x66, 0x74, 0x79, 0x70, 0x4D, 0x34, 0x41 });
            _signatures.Add("MS Visual Stylesheet", new byte[] { 0x3C, 0x3F, 0x78, 0x6D, 0x6C, 0x20, 0x76, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D });
            _signatures.Add("Windows shortcut", new byte[] { 0x4C, 0x00, 0x00, 0x00, 0x01, 0x14, 0x02, 0x00 });
            _signatures.Add("MIDI Sound", new byte[] { 0x4D, 0x54, 0x68, 0x64 });
            _signatures.Add("MP3 Audio", new byte[] { 0x49, 0x44, 0x33 });
            _signatures.Add("MS Installer Package", new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 });
            _signatures.Add("Portable Document File", new byte[] { 0x25, 0x50, 0x44, 0x46 });
            _signatures.Add("MS Powerpoint", new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 });
            _signatures.Add("Photoshop document", new byte[] { 0x38, 0x42, 0x50, 0x53 });
            _signatures.Add("Windows registry file", new byte[] { 0x52, 0x45, 0x47, 0x45, 0x44, 0x49, 0x54 });
            _signatures.Add("tar archive", new byte[] { 0x75, 0x73, 0x74, 0x61, 0x72 });
            _signatures.Add("bzip2 compressed archive", new byte[] { 0x42, 0x5A, 0x68 });
            _signatures.Add("Zip archive v1", new byte[] { 0x50, 0x4B, 0x03, 0x04 });
            _signatures.Add("Zip archive v2", new byte[] { 0x50, 0x4B, 0x05, 0x06 });
            _signatures.Add("Zip archive v3", new byte[] { 0x50, 0x4B, 0x07, 0x08 });
            _signatures.Add("PKLite archive", new byte[] { 0x50, 0x4B, 0x4C, 0x49, 0x54, 0x45 });
            _signatures.Add("Winzip compressed archive", new byte[] { 0x57, 0x69, 0x6E, 0x5A, 0x69, 0x70 });
            _signatures.Add("Self extracting zip archive", new byte[] { 0x50, 0x4B, 0x53, 0x70, 0x58 });
        }
    }

    public static class MagicFinder
    {
        private static List<string> _result = new List<string>();

        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        static string SizeSuffix(long value, int decimalPlaces = 0)
        {
            if (value < 0)
            {
                throw new ArgumentException("Bytes should not be negative", "value");
            }
            var mag = (int)Math.Max(0, Math.Log(value, 1024));
            var adjustedSize = Math.Round(value / Math.Pow(1024, mag), decimalPlaces);
            return String.Format("{0} {1}", adjustedSize, SizeSuffixes[mag]);
        }

        /// <summary>
        /// Reads the contents of a file into an array of bytes.
        /// </summary>
        /// <param name="filePath"></param>
        public static byte[] HexFile(string filePath)
        {
            if (filePath != null && filePath.Length != 0) //Input validation check
            {
                try
                {
                    byte[] bytes = File.ReadAllBytes(filePath); //Try to read the file into an array of bytes
                    return bytes;
                }
                catch (Exception ex) //We were unable to read the file
                {
                    Program.printError(@"", ex);
                    Program.printFooter();
                    Environment.Exit(-1);
                    return null;
                }
            }
            else
            {
                Program.printError(@"Error: Please specify a valid file.");
                Program.printFooter();
                Environment.Exit(-1);
                return null;
            }

        }

        public static void HexDump(byte[] buffer, int maxBytes, int lineSize)
        {
            int currentByte = 0;
            int currentChar = 0;
            Console.WriteLine(@"");
            Console.Write(@" ");
            foreach (byte b in buffer)
            {
                Console.Write(b.ToString("X2") + @" ");
                currentByte++;
                currentChar++;
                if (currentByte == maxBytes)
                {
                    Console.WriteLine(@"");
                    return;
                }
                if (currentChar == 16)
                {
                    Console.WriteLine(@"");
                    Console.Write(@" ");
                    currentChar = 0;
                }
            }
            Console.WriteLine(@"");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">The path to the file to be dumped in hex</param>
        /// <param name="maxBytes">The maximum number of bytes to dump starting at offset 0x0</param>
        /// <param name="lineSize">The size of each line in the dump</param>
        public static void HexDump(string filePath, int maxBytes, int lineSize = 16)
        {

            //Print a new line and a space to nicely format the hexdump in the GUI
            Console.WriteLine(@"");
            Console.Write(@" ");

            byte[] buffer = HexFile(filePath); //read the file into an array of bytes
            int linePosition = 0; //The position of the carret in the terminal

            /*
             * Print out each byte in the array of bytes as a hex value as long as the byte.
             * Continue to do this only as long as the current byte index is smaller 
             * than the maximum bytes to be printed.
            */
            for (int b = 0; b < buffer.Length && b < maxBytes; b++)
            {
                Console.Write(buffer[b].ToString("X2") + @" "); //Write the byte
                linePosition++; //Move the carret to the next space in the line
                if (linePosition >= lineSize) //If we end up at the end of the line print a new line
                {
                    Console.WriteLine(@"");
                    Console.Write(@" ");
                    linePosition = 0; //Set the carret position back to the begin
                }
            }
            Console.WriteLine(@""); //Print a new line
        }
        static public List<int> SearchBytePattern(byte[] pattern, byte[] bytes)
        {
            List<int> positions = new List<int>();
            int patternLength = pattern.Length;
            int totalLength = bytes.Length;
            byte firstMatchByte = pattern[0];
            for (int i = 0; i < totalLength; i++)
            {
                if (firstMatchByte == bytes[i] && totalLength - i >= patternLength)
                {
                    byte[] match = new byte[patternLength];
                    Array.Copy(bytes, i, match, 0, patternLength);
                    if (match.SequenceEqual<byte>(pattern))
                    {
                        positions.Add(i);
                        i += patternLength - 1;
                    }
                }
            }
            return positions;
        }

        public static void findMagic(string filePath, bool hexdump)
        {
            Stopwatch performanceMeasure = new Stopwatch();
            performanceMeasure.Start();
            Program.printLn(@" File: " + filePath, ConsoleColor.DarkGray, ConsoleColor.White);

            if (filePath != null && filePath.Length != 0)
            {
                byte[] file = HexFile(filePath);
                Program.printLn(@" Size: " + SizeSuffix(file.Length), ConsoleColor.DarkGray, ConsoleColor.White);
                if (hexdump)
                {
                    HexDump(file, 100, 16);
                    Console.WriteLine(@"");
                }

                if(file.Length <= 0)
                {
                    Program.printError(@"Error: The file can not be empty.");
                }
                try
                {
                    var magic = new Magic();
                    foreach(var signature in magic.Signatures)
                    {
                        var searchResult = SearchBytePattern(signature.Value, file);
                        if(searchResult.Count > 0)
                        {
                            foreach(int offset in searchResult)
                            {
                                if (!_result.Contains(offset.ToString("X8"), StringComparer.OrdinalIgnoreCase)){
                                    _result.Add("0x" + offset.ToString("X8") + "\t\t\t\t" + signature.Key);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Program.printError(@"An unknown error occured.", ex);
                }
                if (_result.Count <= 0)
                {
                    Program.printLn(@" Unable to detect any signatures in this file.", ConsoleColor.Black, ConsoleColor.DarkYellow);
                }
                else {
                    Console.WriteLine(@"");
                    Console.WriteLine(" Offset:\t\t\t\tMagic:\t\t\t\tElapsed time: " );
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    _result.Sort();
                    foreach (string line in _result)
                    {
                        Console.WriteLine(@" " +line);
                    }
                    Console.ResetColor();
                }
            }
            else
            {
                Program.printError(@"Please specify a valid file.");
            }
        }
    }
}
