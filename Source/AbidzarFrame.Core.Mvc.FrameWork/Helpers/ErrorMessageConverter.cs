using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AbidzarFrame.Core.Mvc.Helpers
{
    public class ErrorMessageConverter
    {

        protected static ErrorMessageConverter instance = null;

        public static ErrorMessageConverter GetInstance()
        {
            if (instance == null)
            {
                instance = new ErrorMessageConverter();
            }
            return instance;
        }

        protected List<ConversionPattern> conversionRules = new List<ConversionPattern>();

        public ModelStateDictionary Convert(ModelStateDictionary original) {
            foreach (ConversionPattern r in conversionRules)
            {
                for (int i=0; i<original.Count-1; i++)
                {
                    KeyValuePair<String, ModelState> k = original.ElementAt(i);
                    if (r.IsFieldMatched(k.Key))
                    {
                        List<ModelError> l = new List<ModelError>();
                        foreach (ModelError e in k.Value.Errors) 
                        {
                            if (r.IsMatched(e.ErrorMessage))
                            {
                                l.Add(e);
                            }
                        }
                        foreach (ModelError e in l)
                        {
                            k.Value.Errors.Remove(e);
                            k.Value.Errors.Add(r.ConvertedMessage(e.ErrorMessage));
                        }
                    }
                }
            }
            return original;
        }

        public void AddRule(ConversionPattern pattern)
        {
            conversionRules.Add(pattern);
        }
    }
}
