const { env } = require('process');

const target = 'http://www.notes-cloud.net';

const PROXY_CONFIG = [
  {
    context: [
      "/Notebook",
      "/User",
      "/Note",
      "/Media",
      "/UserNotebook"
   ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
