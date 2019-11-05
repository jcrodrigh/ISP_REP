using isp.platformb2b.models.entities;
using isp.platformb2b.web.entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace isp.platformb2b.web.Helpers
{
    public class documento_sftp
    {

        private IHostingEnvironment _hostingEnvironment;
        private IOptions<CredencialSmtp> _isettingftp;


        public documento_sftp(IHostingEnvironment hostingEnvironment,
                              IOptions<CredencialSmtp> isettingftp)
        {
            _hostingEnvironment = hostingEnvironment;
            _isettingftp = isettingftp;
        }

        public ResultMessage<FileDocument> LecturaArchivoSfp(string nombre_file,string tipo_documento)
        {
            ResultMessage<FileDocument> _resultado = new ResultMessage<FileDocument>();
            FileDocument _filedocument = new FileDocument();

            Boolean findDocument = false;

            var credencialftp = _isettingftp.Value;

            String AsBase64String = string.Empty;
            string host = credencialftp.host;
            string username = credencialftp.username;
            string password = credencialftp.password;
            string remoteDirectory = string.Empty;

            switch (tipo_documento)
            {
                case "01": //factura
                    remoteDirectory = credencialftp.dirServerFactura;
                    break;
                case "02": //recibo  
                    remoteDirectory = credencialftp.dirServerRecibo;
                    break;
                case "03": //boleta  
                    remoteDirectory = credencialftp.dirServerBoleta;
                    break;
                case "07": //credito  
                    remoteDirectory = credencialftp.dirServerCredito;
                    break;
                case "08": //debito  
                    remoteDirectory = credencialftp.dirServerDebito;
                    break;
            }

            string localFullPath = CreatePath(nombre_file);
            using (var sftp = new SftpClient(host, username, password))
            {

                try
                {
                    sftp.Connect();
                    var files = sftp.ListDirectory(remoteDirectory);
                    WebClient request = new WebClient();
                    foreach (var file in files)
                    {
                        if (!file.Name.StartsWith("."))
                        {
                            if (file.Name.ToString() == nombre_file)
                            {
                                string remoteFileName = file.Name;

                                using (Stream file1 = File.OpenWrite(localFullPath))
                                {
                                    sftp.DownloadFile(remoteDirectory + remoteFileName, file1);
                                }

                                byte[] AsBytes = File.ReadAllBytes(localFullPath);
                                AsBase64String = Convert.ToBase64String(AsBytes);

                                _filedocument.nombre_file = remoteFileName;
                                _filedocument.data = AsBase64String;
                                _filedocument.content_type = "application/pdf";

                                findDocument = true;
                                break;
                            }


                        }
                    }

                    if (!findDocument)
                    {
                        _resultado.Code = 1;
                        _resultado.Message = "No se encontro el documento en el Servidor.";
                    }
                    else
                    {
                        _resultado.Content = _filedocument;
                        _resultado.Code = 0;
                        _resultado.Message = "";
                    }

                    sftp.Disconnect();


                }
                catch (Exception ex)
                {
                    _resultado.Code = 1;
                    _resultado.Message = ex.ToString();
                }
                finally {
                    //eliminamos el registro creado en la carpeta temporal
                    DeleteFilePath(localFullPath);
                }


            }

            return _resultado;
        }

        private void DeleteFilePath(string fullpath)
        {
            //System.IO.FileInfo fi = new System.IO.FileInfo(fullpath);
            System.IO.File.Delete(fullpath);
            //fi.Delete();
        }

        private string CreatePath(string nameFile)
        {


            string folderName = "temp";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string pdfPath = Path.Combine(webRootPath, folderName);

            if (!Directory.Exists(pdfPath))
            {
                Directory.CreateDirectory(pdfPath);
            }

            string fullPath = Path.Combine(pdfPath, nameFile);
            return fullPath;
        }
    }
}
