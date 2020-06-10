import React, { Component } from 'react';

export class FileUploader extends Component {
    render() {
        return (
            <div>
                <input type="file" onChange={this.props.onFileCange} accept='.csv, .xml' />
            </div>
        );
    }
}

export default FileUploader;