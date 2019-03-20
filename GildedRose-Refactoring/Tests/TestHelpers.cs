namespace GildedRose_Refactoring.Tests
{
    public static class TestHelpers
    {
        public static void AdvanceTime(this GildedRose app, int numberOfDays)
        {
            for (int i = 0; i < numberOfDays; i++)
            {
                app.UpdateQuality();
            }
        }
    }
}