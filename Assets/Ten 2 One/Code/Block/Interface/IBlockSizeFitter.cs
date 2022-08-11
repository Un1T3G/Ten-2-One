namespace Un1T3G.Ten2One
{
    public interface IBlockSizeFitter
    {
        IBoard Board { get; }

        bool CanFit(IBlock block);
    }
}