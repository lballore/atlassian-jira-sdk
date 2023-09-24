# atlassian-jira-sdk

A wrapper for RESt APIs for .NET developers to interact with [Jira](http://www.atlassian.com/software/jira), a suite of agile work management solutions developed by Atlassian.

## Support Notice

All features are tested on Jira v8.5.2

## License

This project is licensed under  [BSD](/LICENSE.md).

## Dependencies & Requirements

- [RestSharp](https://www.nuget.org/packages/RestSharp)
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json)
- Tested with JIRA v8.5.2

# History

This project began in 2010 during a [ShipIt](https://www.atlassian.com/company/shipit) day at Atlassian with provider,
to query Jira issues using LINQ syntax. For a description changes, check out the [Change History Page](/docs/change-history.md).

Due to time constraints, this project is no longer mantained by his creator, [Federico Silva Armas](https://bitbucket.org/farmas/).
Being the need for such a library still high, I decided to fork and update it.

## Documentation

The documentation guides can be found under the [docs](/docs) folder.

### Table of contents

1. [Changelog](CHANGELOG.md)
2. Guides
    1. [How to use the SDK](/docs/how-to-use-the-sdk.md)
    2. [How to connect using OAuth](/docs/how-to-connect-using-oauth.md)
    3. [How to run the integration tests](/docs/how-to-run-the-integration-tests.md)
    4. [How to debug problems](/docs/how-to-debug-problems.md)
    5. [How to work with custom fields](/docs/how-to-use-custom-fields.md)
    6. [How to handle changes due to GDPR](/docs/how-to-handle-gdpr-changes.md)
    7. [How to configure fields to download when querying issues](how-to-configure-issue-fields-to-fetch.md)
3. Reference
    1. [JQL Supported Operators](/docs/reference-jql.md)
