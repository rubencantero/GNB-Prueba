using AutoMapper;
using GNB.Bussiness.Application.DTOs.DTO;
using GNB.Bussiness.BD.DataAcces;
using GNB.Bussiness.BD.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Bussinsess.Utils.Utils
{
    public class FilesOffline
    {
        public const string FilePathConversions = @"C:\Storage\Conversions.dat";
        public const string FilePathTransactions = @"C:\Storage\Transactions.dat";

        public static void GenerateFiles()
        {
            GenerateFileConversion();
            GenerateFileTransaction();
        }

        public FilesOffline()
        {

        }
        public static void GenerateFileConversion()
        {
            StreamWriter sw = null;
            try
            {
                LogManager.Write("GenerateFilesOffline.GenerateFileConversion()");
                TransactionsDao dao = new TransactionsDao();
                List<Conversions> listConversions = dao.GetConversions();
                CreateIfnotExistFile(FilePathConversions);
                sw = new StreamWriter(FilePathConversions);

                string Text = ObjectToBase64(listConversions);
                sw.Write(Text);
                sw.Close();
            }
            catch (Exception ex)
            {
                LogManager.Write("GenerateFilesOffline.GenerateFileConversion() ERROR:" + ex.Message);
                if (sw != null)
                    sw.Close();
            }
        }


        public static void GenerateFileTransaction()
        {
            StreamWriter sw = null;
            try
            {
                LogManager.Write("GenerateFilesOffline.GenerateFileTransaction()");
                TransactionsDao dao = new TransactionsDao();
                List<Transactions> listTransactions = dao.GetTransactions();
                CreateIfnotExistFile(FilePathTransactions);
                sw = new StreamWriter(FilePathTransactions);

                string Text = ObjectToBase64(listTransactions);
                sw.Write(Text);
                sw.Close();
            }
            catch (Exception ex)
            {
                LogManager.Write("GenerateFilesOffline.GenerateFileTransaction() ERROR:" + ex.Message);
                if (sw != null)
                    sw.Close();
            }
        }

        public List<TransactionsDTO> getFileTransactions()
        {
                string text = string.Empty;
            try
            {
                CreateIfnotExistFile(FilePathTransactions);
                List<TransactionsDTO> listTransactions = new List<TransactionsDTO>();
                StreamReader sr = new StreamReader(FilePathTransactions);
                text = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                LogManager.Write("GenerateFilesOffline.getFileTransactions() ERROR:" + ex.Message);      
               
            }
                return Mapper.Map<List<TransactionsDTO>>(Base64ToObject<IEnumerable<Transactions>>(text).ToList());
        }

        public List<ConversionsDTO> getFileConversions()
        {
                string text = string.Empty;
            try
            {
                CreateIfnotExistFile(FilePathTransactions);
                List<ConversionsDTO> listTransactions = new List<ConversionsDTO>();
                StreamReader sr = new StreamReader(FilePathConversions);
                text = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                LogManager.Write("GenerateFilesOffline.getFileConversions() ERROR:" + ex.Message);
            }
            return Mapper.Map<List<ConversionsDTO>>(Base64ToObject<IEnumerable<Conversions>>(text).ToList());
        }


        public static string ObjectToBase64<T>(List<T> obj) where T : new()
        {
            object ObjectToSerialize = obj;
            string Json = JsonConvert.SerializeObject(ObjectToSerialize, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, });

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(Json));
        }
        public static T Base64ToObject<T>(string str)
        {
            string Json = Encoding.UTF8.GetString(Convert.FromBase64String(str));
            T Object = JsonConvert.DeserializeObject<T>(Json);

            return Object;
        }
        public static void CreateIfnotExistFile(string path)
        {
            try
            {
                string directoryPath = Path.GetDirectoryName(path);
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                if (!File.Exists(path))
                {
                    StreamWriter sw = new StreamWriter(path);
                    sw.Write("");
                    sw.Close();
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
