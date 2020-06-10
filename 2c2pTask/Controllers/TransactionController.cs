using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using _2c2pTask.Attributes;
using _2c2pTask.Models.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2c2pTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        [Route("BulkUpload")]
        public ActionResult<string> BulkUpload([MaxFileSize(Constants.MAX_FILE_SIZE)] 
                                               [AllowedExtensionsAttribute(new string[] { Constants.CSV_FORMAT, Constants.XML_FORMAT })]
                                                IFormFile file)
        {
            return "test response";
        }
    }
}