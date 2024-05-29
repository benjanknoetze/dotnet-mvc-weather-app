module.exports = {
  content: [
    './Views/**/*.cshtml',
    './wwwroot/**/*.html',
    './wwwroot/**/*.js',
  ],
  theme: {
    extend: {
      boxShadow: {
        'custom-light': 'rgba(99, 99, 99, 0.2) 0px 2px 8px 0px',
      }
    },
  },
  plugins: [],
};
