﻿using System;
using System.Linq;
using RestSharp;
using Xunit;

namespace Atlassian.Jira.Test.Integration
{
    public class RestTest : BaseIntegrationTest
    {
        [Fact]
        public void ExecuteRestRequest()
        {
            var users = _jira.RestClient.ExecuteRequestAsync<JiraNamedResource[]>(Method.GET, "rest/api/2/user/assignable/multiProjectSearch?projectKeys=TST").Result;

            Assert.True(users.Length >= 2);
            Assert.Contains(users, u => u.Name == "admin");
        }

        [Fact]
        public void ExecuteRawRestRequest()
        {
            var issue = new Issue(_jira, "TST")
            {
                Type = "1",
                Summary = "Test Summary " + _random.Next(int.MaxValue),
                Assignee = "admin"
            };

            issue.SaveChanges();

            var rawBody = String.Format("{{ \"jql\": \"Key=\\\"{0}\\\"\" }}", issue.Key.Value);
            var json = _jira.RestClient.ExecuteRequestAsync(Method.POST, "rest/api/2/search", rawBody).Result;

            Assert.Equal(issue.Key.Value, json["issues"][0]["key"].ToString());
        }
    }
}
