namespace Talent.Backend.Service.Dtos
{
    public class UserPointResponseDto<T>
    {
        public T Element { get; set; }
        public double Points { get; set; }
    }
}
