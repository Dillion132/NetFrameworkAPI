using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetFrameworkAPI.Models
{
    public class TodoModel
    {
        [Key]
        public int TodoId { get; set; }
        public string actorname { get; set; }
        public string taskname { get; set; }
        public string stepname { get; set; }
        public List<Parameter> parameters { get; set; }
    }
    public class Parameter
    {
        [Key]
        public int PId { get; set; }
        public string name { get; set; }
        public double value { get; set; }
    }
}