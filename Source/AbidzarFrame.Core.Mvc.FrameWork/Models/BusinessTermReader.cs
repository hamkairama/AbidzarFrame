using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AbidzarFrame.Core.Mvc.Models
{
    public class BusinessTermReader : IBusinessTermReader
    {

        private StreamReader _reader = null;
        private BusinessTerm _term = null;
        private String _lastLine = null;

        public BusinessTermReader(FileStream file)
        {
            _reader = new StreamReader(file);
        }

        public bool Next()
        {
            //Sample:
            //[FIELD_ANS_TRANSACTION_TYPES]
            //00001 : {en, Policy Overdue}; {id, Policy Overdue}
            //ANS001: {en, Pls re-submit reinstatement documents}; {id, Pls re-submit reinstatement documents}
            //ANS002: {en, Test Description A}; {id, Test Description A}
            //ANS003: {en, Test Description I}; {id, Test Description I}
            //ANS004: {en, Test Description W}; {id, Test Description W}
            //[FIELD_ANS_SAMPLE_TYPES]
            //B00001: {en, Policy Overdue}; {id, Policy Overdue}
            //B00002: {en, Test Description A}; {id, Test Description A}

            _term = null;
            if (_lastLine != null || !_reader.EndOfStream)
            {
                while (_lastLine != null || !_reader.EndOfStream)
                {
                    String _l = null;
                    if (_lastLine == null)
                    {
                        _l = ReadLine();
                    }
                    else
                    {
                        _l = _lastLine;
                        _lastLine = null;
                    }
                    if (_l != null && !_l.Trim().StartsWith("#"))
                    {
                        _l = _l.Trim();
                        if (_l.StartsWith("[") && _l.EndsWith("]"))
                        {
                            //[AnsTransactionTypes]
                            _term = new BusinessTerm(_l.Substring(1, _l.Length - 2));
                            while (!_reader.EndOfStream)
                            {
                                //00001 : {en, Policy Overdue}, {id, Policy Overdue}
                                _l = ReadLine();
                                if (_l != null && !_l.Trim().StartsWith("#"))
                                {
                                    _l = _l.Trim();
                                    if (_l.StartsWith("[") && _l.EndsWith("]"))
                                    {
                                        _lastLine = _l;
                                        break;
                                    }

                                    String[] words = _l.Split(":".ToCharArray());
                                    if (words.Length >= 2)
                                    {
                                        String _value = words[0].Trim();        //00001
                                        String[] _definitions = words[1].Trim().Split(";".ToCharArray());
                                        foreach (String _definition in _definitions)
                                        {
                                            //{en, Policy Overdue}
                                            String _content = _definition.Trim();
                                            _content = _content.Substring(1, _content.Length - 2);

                                            String[] _w = _content.Split(",".ToCharArray());
                                            TermContent _t = new TermContent(_w[0].Trim(), _w[1].Trim());

                                            _term.AddValueDescription(_value, _t);
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
            return (_term != null);
        }

        public BusinessTerm GetBusinessTerm()
        {
            return _term;
        }

        private String ReadLine()
        {
            String _line = _reader.ReadLine();
            return _line;
        }

    }
}
