Imports Manulife.Core.Model.Business

Public Interface IDbConnFactoryExt
    Inherits IDbConnFactory

    Overloads Function CreateInputParameter(ByVal fieldName As String, ByVal udtTypeName As String, ByVal value As Object) As System.Data.IDataParameter
End Interface
