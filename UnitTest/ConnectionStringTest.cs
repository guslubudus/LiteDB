using LiteDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UnitTest {
    [TestClass]
    public class ConnectionStringTest {
        List<string> kvpBase = new List<string> { "filename=test.db" };

        [TestMethod]
        public void ConnectionString_FilenameParsing( ) {
            var cs = new ConnectionString( string.Join( ";", kvpBase ) );
            Assert.AreEqual( Path.GetFileName( cs.Filename ), "test.db", "filename test" );
        }

        [TestMethod]
        public void ConnectionString_TimeoutParsing( ) {
            var timeoutCS = new List<string>( kvpBase ) { "timeout=00:10:00" };
            var cs = new ConnectionString( string.Join( ";", timeoutCS ) );
            Assert.AreEqual( cs.Timeout, TimeSpan.Parse( "00:10:00" ), "timeoutCS test" );
        }

        [TestMethod]
        public void ConnectionString_JournalParsing( ) {
            var journalEnabledFalse = new List<string>( kvpBase ) { "journal=false" };
            var cs = new ConnectionString( string.Join( ";", journalEnabledFalse ) );
            Assert.AreEqual( cs.JournalEnabled, false, string.Format( "bool literal journalEnabled test {0}", cs.JournalEnabled ) );

            var journalEnabledTrue = new List<string>( kvpBase ) { "journal=true" };
            cs = new ConnectionString( string.Join( ";", journalEnabledTrue ) );
            Assert.AreEqual( cs.JournalEnabled, true, string.Format( "bool literal int journalEnabled test {0}", cs.JournalEnabled ) );
        }

        [TestMethod]
        public void ConnectionString_UserVersionParsing( ) {
            var journalEnabledFalse = new List<string>( kvpBase ) { "version=2" };
            var cs = new ConnectionString( string.Join( ";", journalEnabledFalse ) );
            Assert.AreEqual( cs.UserVersion, 2, "UserVersion test" );
        }
    }
}
