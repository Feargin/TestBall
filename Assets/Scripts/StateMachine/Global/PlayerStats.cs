namespace Global
{
    public sealed class PlayerStats
    {
        internal event System.Action<TypeStats, int> OnStatChange;

        public void StatChange(TypeStats typeStats, int value)
        {
            OnStatChange?.Invoke(typeStats, value);
        }
    }

    public enum TypeStats
    {
        Score,
        Other,
    }
}