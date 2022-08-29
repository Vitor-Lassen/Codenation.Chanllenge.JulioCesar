using Codenation.Chanllenge.JulioCesar.Interfaces;
using Codenation.Chanllenge.JulioCesar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Chanllenge.JulioCesar.App
{
    class Application
    {
        private readonly ICodenationService _codenationService;
        private readonly ICriptService _criptService;
        private readonly IFileRepository<CriptDTO> _fileRepository;
        public Application(ICodenationService codenationService,
                           ICriptService criptService,               
                           IFileRepository<CriptDTO> fileRepository)
        {
            _codenationService = codenationService;
            _criptService = criptService;
            _fileRepository = fileRepository;
        }
        public void Exec()
        {
            var path = @"D:\teste\";
            var fileName = "answer";

            var teste = 1;
            

            Console.WriteLine("Start Application");
            Console.WriteLine("Input token:");
            var token = Console.ReadLine();

            Console.WriteLine("Sending request to codenation API:");
            var cript =  _codenationService.GetCript(token);
            Console.WriteLine($"API response: {JsonConvert.SerializeObject(cript, Formatting.Indented)}");

            Console.WriteLine("DecriptJulioCesar:");
            cript.Textdecript = _criptService.DecriptJulioCesar(cript.TextCript, cript.Key);
            Console.WriteLine(cript.Textdecript);

            Console.WriteLine("Sha1");
            cript.ResumoCript =_criptService.GetHashSha1(cript.Textdecript);

            Console.WriteLine("Save results");
            _fileRepository.SaveFile(fileName,path , cript);

            Console.WriteLine("send result to API:");
            var result = _codenationService.SendFileDecript($"{path}{fileName}.json", fileName, token);
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));


        }
    }
}
