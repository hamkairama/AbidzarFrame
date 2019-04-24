using System;
namespace AbidzarFrame.Core.Mvc.Models
{
    interface IBusinessTermReader
    {
        BusinessTerm GetBusinessTerm();
        bool Next();
    }
}
