namespace Library
{
    public interface ITablePart 
    {
        void Accept(ITableVisitor visitor);
    }
}