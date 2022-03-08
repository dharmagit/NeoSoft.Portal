using HDFC.Core.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using NeoSoft.Portal.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;

using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.Portal.Service.Helpers
{
    public class CommonHelper
    {
        public string generateJwtToken(AuthenticateRequest authenticationRequest)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("NeoSoftMapProject");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", authenticationRequest.Username.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

       
        public string SaveBase64ToImage(string base64Image, IHostingEnvironment _hostingEnvironment, string folderName, string fileName)
        {
            string strm = base64Image;
            string path = _hostingEnvironment.WebRootPath;

            var pathToData = Path.GetFullPath(Path.Combine(path, folderName + "\\"));

            string filepath = pathToData + fileName;
            //Generate unique filename
            try
            {

                var bytess = Convert.FromBase64String(strm);
                using (var imageFile = new FileStream(filepath, FileMode.Create))
                {
                    imageFile.Write(bytess, 0, bytess.Length);
                    imageFile.Flush();
                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return filepath;


        }

        public static string GetRandomKey(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public static void ExportCsv<T>(List<T> genericList, string finalPath)
        {
            var sb = new StringBuilder();
            //var basePath = AppDomain.CurrentDomain.BaseDirectory;
            //var finalPath = Path.Combine(basePath, fileName + ".csv");
            var header = "";
            var info = typeof(T).GetProperties();
            if (!File.Exists(finalPath))
            {
                var file = File.Create(finalPath);
                file.Close();
                foreach (var prop in typeof(T).GetProperties())
                {
                    header += prop.Name + ", ";
                }
                header = header.Substring(0, header.Length - 2);
                sb.AppendLine(header);
                TextWriter sw = new StreamWriter(finalPath, true);
                sw.Write(sb.ToString());
                sw.Close();
            }
            foreach (var obj in genericList)
            {
                sb = new StringBuilder();
                var line = "";
                foreach (var prop in info)
                {
                    line += prop.GetValue(obj, null) + ", ";
                }
                line = line.Substring(0, line.Length - 2);
                sb.AppendLine(line);
                TextWriter sw = new StreamWriter(finalPath, true);
                sw.Write(sb.ToString());
                sw.Close();
            }
        }

    }
}
