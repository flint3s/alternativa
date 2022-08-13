const path = require("path");
module.exports = {
    mode: "production",
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: "ts-loader",
                exclude: /node_modules/
            }
        ]
    },
    entry: {
        "AdminPanel": "./src/AdminPanel/index.ts",
        "CursorManager": "./src/CursorManager/index.ts",
    },
    resolve: {
        extensions: [".ts"]
    },
    experiments: {
        cacheUnaffected: false,
    },
    watchOptions: {
        ignored: "**/node_modules"
    },
    output: {
        filename: "[name]/[name].js",
        path: path.resolve(__dirname, "..", "..", "client_packages", "js_packages"),
    }
};
