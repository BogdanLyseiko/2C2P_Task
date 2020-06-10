import React, { Component } from 'react';
import FileUploader from './file-uploader';
import { TransactionService } from '../services/transaction-service';

export class Home extends Component {
  state = {
    selectedFile: null
  };

  onFileCange = (event) => {
    this.setState({ selectedFile: event.target.files[0] });
}

onUploadButtonClick = () => {
  TransactionService.bulkUpload(this.state.selectedFile);
}

  render() {
    return (
      <div>
        <FileUploader onFileCange={this.onFileCange} />
        <button disabled={!this.state.selectedFile} onClick={this.onUploadButtonClick}>Upload file</button>
      </div>
    );
  }
}
