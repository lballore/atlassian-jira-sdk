﻿using System;

namespace Atlassian.Jira.OAuth
{
    /// <summary>
    /// Access token information returned by Jira.
    /// </summary>
    public class OAuthAccessToken
    {
        /// <summary>
        /// The OAuth access token generated by Jira.
        /// </summary>
        public readonly string OAuthToken;

        /// <summary>
        /// The OAuth token secret generated by Jira.
        /// </summary>
        public readonly string OAuthTokenSecret;

        /// <summary>
        /// The expiry date of the access token.
        /// </summary>
        public readonly DateTimeOffset OAuthTokenExpiry;

        /// <summary>
        /// Creates a request token containing the response from Jira.
        /// </summary>
        /// <param name="oAuthToken">The OAuth access token generated by Jira.</param>
        /// <param name="oAuthTokenSecret">The OAuth token secret generated by Jira.</param>
        /// <param name="expiry">The expiry date of the access token.</param>
        public OAuthAccessToken(string oAuthToken, string oAuthTokenSecret, DateTimeOffset oAuthTokenExpiry)
        {
            OAuthToken = oAuthToken;
            OAuthTokenSecret = oAuthTokenSecret;
            OAuthTokenExpiry = oAuthTokenExpiry;
        }
    }
}
