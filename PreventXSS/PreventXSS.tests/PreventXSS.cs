using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PreventXSS.tests {
    [TestClass]
    public class PreventXSS {
        [TestMethod]
        public void TestSanitizeHTML() {
            //arrange
            var secure = new Security();
            var list = new SafeTags();

            //act
            var result = secure.SanitizeHTML("<b>hello</b><script>evil</script>", list.TagList);

            //assert
            Assert.AreEqual(@"<b>hello</b>&lt;script&gt;evil&lt;/script&gt;", result);

        }

        [TestMethod]
        public void TestSanitizeHTMLTagIsFirst() {
            //arrange
            var secure = new Security();
            var list = new SafeTags();

            //act
            var result = secure.SanitizeHTML("<script>evil</script><b>hello</b>", list.TagList);

            //assert
            Assert.AreEqual(@"&lt;script&gt;evil&lt;/script&gt;<b>hello</b>", result);

        }

        [TestMethod]
        public void TestSanitizeHTMLNoUnsafe() {
            //arrange
            var secure = new Security();
            var list = new SafeTags();

            //act
            var result = secure.SanitizeHTML("<b>hello</b><body>evil</body>", list.TagList);

            //assert
            Assert.AreEqual(@"<b>hello</b>&lt;script&gt;evil&lt;/script&gt;", result);

        }
    }
}
