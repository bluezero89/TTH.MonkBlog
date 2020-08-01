const ENV = {
  dev: {
    apiUrl: 'http://localhost:44370',
    oAuthConfig: {
      issuer: 'http://localhost:44370',
      clientId: 'MonkBlog_App',
      clientSecret: '1q2w3e*',
      scope: 'MonkBlog',
    },
    localization: {
      defaultResourceName: 'MonkBlog',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44370',
    oAuthConfig: {
      issuer: 'http://localhost:44370',
      clientId: 'MonkBlog_App',
      clientSecret: '1q2w3e*',
      scope: 'MonkBlog',
    },
    localization: {
      defaultResourceName: 'MonkBlog',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
