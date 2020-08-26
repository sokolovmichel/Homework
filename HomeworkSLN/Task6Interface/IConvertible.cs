namespace Task6Interface
{
    /// <summary>
    /// Определяет два метода, конвертирующие строку кода в C# или VB
    /// </summary>
    interface IConvertible
    {
        /// <summary>
        /// Конвертирует строку кода в код C#
        /// </summary>
        string ConvertToCSharp(string myString);
        /// <summary>
        /// Конвертирует строку кода в код VB
        /// </summary>
        string ConvertToVB(string myString);
    }
}
