export const environment = {
  production: true,
  application: {
    name: 'MonkBlog',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44327',
    clientId: 'MonkBlog_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'MonkBlog',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44389',
    },
  },
  localization: {
    defaultResourceName: 'MonkBlog',
  },
};
