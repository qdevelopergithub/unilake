module.exports = {
    content: ["./**/*.{html,js,mjs,md,cshtml,razor,cs}", "./Pages/**/*.{cshtml,razor}", "./node_modules/flowbite/**/*.js"],
  darkMode: 'class',
    plugins: [require('flowbite/plugin')],
    theme: {
        colors: {
            'lightBlack':'#202020'
        }
    }
}
