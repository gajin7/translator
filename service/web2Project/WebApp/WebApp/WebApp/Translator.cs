using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace WebApp
{
    public class Translator
    {
        public static String Translate(String text)
        {
            string retVal = "";
            if ((retVal = XmlHelper.SearchDB(text)) != "")
                return retVal;
            

            var fromLanguage = ConfigurationManager.AppSettings["LanguageFrom"];//English
            var toLanguage = ConfigurationManager.AppSettings["LanguageTo"];//Serbian
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(text)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Error";
            }
        }

        
    }
}