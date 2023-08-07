namespace SchoolRecords.Api.ViewModels
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string key, string message)
        {
            this.Key = key;
            this.Message = message;
        }

        /// <summary>
        /// Código de erro
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Mensagem de erro
        /// </summary>
        public string Message { get; private set; }
    }
}
