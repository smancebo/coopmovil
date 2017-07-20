using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace ibanking.Services
{
    public class ApiParams
    {
        List<Parameter> _params;

        public ApiParams()
        {
            this._params = new List<Parameter>();
        }

        public void Add(Parameter param){
            param.Index = this._params.Count;
            this._params.Add(param);
        }

        public void Add(string Key, object Val){
            this.Add(new Parameter() { Key = Key, Val = Val});
        }

        public string ToJson(){
            var sb = new StringBuilder();
            sb.Append("{");

            var orderedParams = _params.OrderBy(x => x.Index).ToList();

            var LastParam = orderedParams.Last();

            foreach (Parameter p in orderedParams)
            {
                string val = "";
                if(p.Val is String)
                {
                    val = $"\"{p.Val}\"";
                }
                else if(p.Val is bool)
                {
                    val = p.Val.ToString().ToLower();
                }
                else{
                    
                    val = p.Val.ToString();
                }

                if(p.Equals(LastParam)){
                    sb.Append($"\"{p.Key}\" :  {val}");    
                }
                else{
                    sb.Append($"\"{p.Key}\" :  {val}, ");
                }

            }
            sb.Append("}");

            return sb.ToString();
        }


    }

    public class Parameter
    {
        public int Index { get; set; }
        public string Key { get; set; }
        public object Val { get; set; }

        public Parameter(){
            this.Index = 0;
            this.Key = "";
            this.Val = "";
        }
    }
}
