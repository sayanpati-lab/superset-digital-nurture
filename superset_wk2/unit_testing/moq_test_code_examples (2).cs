// Moq + NUnit Testing Examples
// Language: C#

// ============================
// 📧 Example 1: Mocking Mail Sender
// ============================
[TestFixture]
public class CustomerCommTests
{
    private Mock<IMailSender> _mockMailSender;
    private CustomerComm _customerComm;

    [OneTimeSetUp]
    public void Init()
    {
        _mockMailSender = new Mock<IMailSender>();
        _mockMailSender.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

        _customerComm = new CustomerComm(_mockMailSender.Object);
    }

    [TestCase]
    public void SendMailToCustomer_ShouldReturnTrue()
    {
        var result = _customerComm.SendMailToCustomer();
        Assert.That(result, Is.True);
    }
}

// ============================
// 📁 Example 2: Mocking File System
// ============================
[TestFixture]
public class DirectoryExplorerTests
{
    private Mock<IDirectoryExplorer> _mockExplorer;
    private readonly string _file1 = "file.txt";
    private readonly string _file2 = "file2.txt";

    [OneTimeSetUp]
    public void Init()
    {
        _mockExplorer = new Mock<IDirectoryExplorer>();
        _mockExplorer.Setup(m => m.GetFiles(It.IsAny<string>())).Returns(new List<string> { _file1, _file2 });
    }

    [TestCase]
    public void GetFiles_ShouldReturnTwoFiles()
    {
        var result = _mockExplorer.Object.GetFiles("dummyPath");
        Assert.IsNotNull(result);
        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result, Contains.Item(_file1));
    }
}

// ============================
// 🧑‍💻 Example 3: Mocking Database Access
// ============================
[TestFixture]
public class PlayerManagerTests
{
    private Mock<IPlayerMapper> _mockMapper;

    [SetUp]
    public void Setup()
    {
        _mockMapper = new Mock<IPlayerMapper>();
        _mockMapper.Setup(m => m.IsPlayerNameExistsInDb(It.IsAny<string>())).Returns(false);
        _mockMapper.Setup(m => m.AddNewPlayerIntoDb(It.IsAny<string>()));
    }

    [TestCase("Sachin")]
    public void RegisterNewPlayer_ShouldReturnValidPlayer(string playerName)
    {
        var player = Player.RegisterNewPlayer(playerName, _mockMapper.Object);

        Assert.That(player.Name, Is.EqualTo(playerName));
        Assert.That(player.Age, Is.EqualTo(23));
        Assert.That(player.Country, Is.EqualTo("India"));
        Assert.That(player.NoOfMatches, Is.EqualTo(30));
    }

    [TestCase("")]
    public void RegisterNewPlayer_EmptyName_ShouldThrowException(string playerName)
    {
        Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer(playerName, _mockMapper.Object));
    }
}
