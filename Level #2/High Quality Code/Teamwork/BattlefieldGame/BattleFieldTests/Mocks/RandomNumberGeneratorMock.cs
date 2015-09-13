namespace BattleFieldTests.Mocks
{
    using Battlefield.Interfaces;
    using Moq;

    public class RandomNumberGeneratorMock
    {
        public RandomNumberGeneratorMock()
        {
            this.SetupMock();
        }

        private void SetupMock()
        {
            var mock = new Mock<IRandomNumberGenerator>();

            mock.Setup(rg => rg.GetRandomNumber(
                    It.IsAny<int>(), It.IsAny<int>()))
                .Returns(1);

            this.RandomNumberGenerator = mock.Object;
        }

        public IRandomNumberGenerator RandomNumberGenerator { get; set; }
    }
}
