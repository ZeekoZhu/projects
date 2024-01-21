const fs = require('fs');
const path = require('path');
const apps = fs.readdirSync(path.resolve(__dirname, 'apps'));
module.exports = {
  prompt: {
    scopes: [...apps],
  },
};
