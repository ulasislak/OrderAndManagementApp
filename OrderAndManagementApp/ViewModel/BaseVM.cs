namespace OrderAndManagementApp.ViewModel
{
    public class BaseVM
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
