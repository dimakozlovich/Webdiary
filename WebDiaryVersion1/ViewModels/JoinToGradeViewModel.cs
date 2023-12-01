namespace WebDiaryVersion1.ViewModels
{
    public class JoinToGradeViewModel
    {
        public string guid;
        public Guid ConvertStringToGuid()
        {
            if (guid != null)
                return new Guid(guid);

            else
                return new Guid();
        }
    }
}
