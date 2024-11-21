using System.Dynamic;
using System.Text.Json;
using LoveYuri.Base;

namespace HelloWorld;

public class TestConfig: BaseConfig {
    protected override string BasePath => "test.json";

    public static TestConfig Get() {
        return Load<TestConfig>();
    }

    public string Name {
        get => GetValue("yuri is yes");
        set => SetValue(value);
    }
}