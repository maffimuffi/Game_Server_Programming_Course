using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;


namespace Assignment3 
{

public class NewItem{

        public Guid Id { get; set; }

        public int Level{get; set;}
        public DateTime CreationDate{get;}
        public ItemType ItemType { get; set; }



}

    



}