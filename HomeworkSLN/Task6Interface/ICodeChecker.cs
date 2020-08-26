namespace Task6Interface
{
    /// <summary>
    /// Определяет метод, возвращающий результат проверки строки кода на соответствие заданному языку
    /// </summary>
    interface ICodeChecker
    {
        /// <summary>
        /// Возвращает результат проверки строки кода на соответствие заданному языку
        /// </summary>
        bool CheckCodeSyntax (string convertedCode, string language);
    }
}
