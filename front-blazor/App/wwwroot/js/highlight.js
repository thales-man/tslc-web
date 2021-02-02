"use strict";

window.Markdown = {
    highlight: function () {
        document
            .querySelectorAll('pre code')
            .forEach(block => {
                window.Prism.highlightElement(block);
        });
    }
}