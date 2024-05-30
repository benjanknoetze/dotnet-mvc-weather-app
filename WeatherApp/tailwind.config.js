const defaultTheme = require('tailwindcss/defaultTheme')

module.exports = {
  content: [
    './Views/**/*.cshtml',
    './wwwroot/**/*.html',
    './wwwroot/**/*.js',
  ],
  theme: {
    extend: {
      boxShadow: {
        'custom-light': '#0169aa69 0 0 20px -10px',
        'custom-hover': '#0169aab7 0 0 10px -5px',
      },
      fontFamily: {
        'sans': ['"Outfit"', ...defaultTheme.fontFamily.sans],
      },
      screens: {
        'sm': {'max': '639px'},
      },
    },
  },
  plugins: [],
};
