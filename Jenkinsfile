pipeline {
    agent { dockerfile true }
    stages {
        stage('Build') {
            steps {
                bash '''#!/bin/bash
                    echo "hello world" 
                '''
            }
        }
    }
}