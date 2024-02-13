const PROXY_CONFIG = [
  {
    context: [
      "/Weatherforecast",
    ],
    target: "http://localhost:5147",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
