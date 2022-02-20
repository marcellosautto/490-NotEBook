import React, {Component} from "react";
import { Editor } from "react-draft-wysiwyg";
import {EditorState} from "draft-js"

import "react-draft-wysiwyg/dist/react-draft-wysiwyg.css";

export default class TextEditor extends Component {

  state = {
    editorState: EditorState.createEmpty(),
  }

  onEditorStateChange = (editorState) => {
    this.setState({
      editorState,
    })
  }
  render(){
    const {editorState} = this.state;
    return (
      <Editor
      editorState={editorState}
      toolbarClassName="text__editor__toolbar"
      wrapperClassName="wrapperClassName"
      editorClassName="text__editor"
      onEditorStateChange={this.onEditorStateChange}
    />
    )
  }
}