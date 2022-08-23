namespace Talent.Backend.DataAccessEF.Models
{
    public class UserPointResponse<T>
    {
        public double Points { get; set; }
        public T Element { get; set; }
    }
}
