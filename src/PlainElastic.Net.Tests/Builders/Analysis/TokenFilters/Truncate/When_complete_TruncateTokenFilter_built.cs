using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(TruncateTokenFilter))]
    class When_complete_TruncateTokenFilter_built
    {
        Because of = () => result = new TruncateTokenFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .Length(2)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'truncate'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_length_part = () => result.ShouldContain("'length': 2".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'truncate'," +
                                                                    "'version': '3.6'," +
                                                                    "'length': 2," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}