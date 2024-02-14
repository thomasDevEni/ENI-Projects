const PROXY_CONFIG = [
  {
    context: [
      "/api",
    ],
    target: "http://localhost:4220",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
