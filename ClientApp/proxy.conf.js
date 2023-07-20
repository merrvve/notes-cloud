const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:37503';

const PROXY_CONFIG = [
  {
    context: [
      "/Notebook",
      "/User",
      "/Note",
      "/Media",
      "/UserNotebook"
    ],
    externals: [
      /^googleapis$/,
    ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
